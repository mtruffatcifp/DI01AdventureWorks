-- Otener todas las categorias.
CREATE PROCEDURE spCategory_GetAll
AS
BEGIN
	SET NOCOUNT ON;
	SELECT Production.ProductCategory.Name FROM Production.ProductCategory;
END


-- Obtener a partir de una categoría las subcategorias correspondientes.
CREATE PROCEDURE spSubcategory_GetAll
	@Categoria nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT Production.ProductSubcategory.Name FROM Production.ProductSubcategory WHERE Production.ProductSubcategory.ProductCategoryID = (SELECT Production.ProductCategory.ProductCategoryID FROM Production.ProductCategory WHERE Production.ProductCategory.Name = @Categoria);
END


-- Obtener a partir de una categoria y una subcategoria los tamaños correspondientes.
CREATE PROCEDURE spSize_GetAll
	@Categoria nvarchar(50),
	@Subcategoria nvarchar(50)
AS
BEGIN
	SELECT DISTINCT Production.Product.Size FROM Production.Product
	INNER JOIN Production.ProductSubcategory ON Production.Product.ProductSubcategoryID = Production.ProductSubcategory.ProductSubcategoryID
	WHERE Production.ProductSubcategory.ProductCategoryID = (SELECT Production.ProductCategory.ProductCategoryID FROM Production.ProductCategory WHERE Production.ProductCategory.Name = @Categoria)
	AND Production.ProductSubcategory.Name = @Subcategoria AND Production.Product.Size IS NOT NULL;
END

-- Obtener a partir de una subcategoria las classes correspondientes
CREATE PROCEDURE spClass_GetAll
	@Subcategory nvarchar(50)
AS
BEGIN
	SELECT DISTINCT Production.Product.Class FROM Production.Product 
	WHERE Production.Product.ProductSubcategoryID = (SELECT Production.ProductSubcategory.ProductSubcategoryID FROM Production.ProductSubcategory 
	WHERE Production.ProductSubcategory.Name = @Subcategory) AND Production.Product.Class IS NOT NULL;
END

-- Obtener a partir de una subcategoria los estilos/Style correspondientes
CREATE PROCEDURE spStyle_GetAll
	@Subcategory nvarchar(50)
AS
BEGIN
	SELECT DISTINCT Production.Product.Style FROM Production.Product 
	WHERE Production.Product.ProductSubcategoryID = (SELECT Production.ProductSubcategory.ProductSubcategoryID FROM Production.ProductSubcategory 
	WHERE Production.ProductSubcategory.Name = @Subcategory) Production.Product.Style IS NOT NULL;
END

-- Obtener a partir de una subcategoria los ProductLine correpondientes
CREATE PROCEDURE spProductLine_GetAll
	@Subcategory nvarchar(50)
AS
BEGIN
	SELECT DISTINCT Production.Product.ProductLine FROM Production.Product 
	WHERE Production.Product.ProductSubcategoryID = (SELECT Production.ProductSubcategory.ProductSubcategoryID FROM Production.ProductSubcategory 
	WHERE Production.ProductSubcategory.Name = @Subcategory) AND Production.Product.ProductLine IS NOT NULL;
END

-- Obtener el precio más alto.
CREATE PROCEDURE spMaxPrice_GetAll
AS
BEGIN
	SET NOCOUNT ON;
	SELECT MAX(Production.Product.ListPrice) FROM Production.Product;
END



--------------------------------------------------------------
CREATE PROCEDURE spGeneric_ShowResult
	@Idioma nchar(6),
	@Category nvarchar(50) = null,
	@Subcategory nvarchar(50) = null,
	@Size nvarchar(5) = null,
	@Style nchar(2) = null,
	@Class nchar(2) = null,
	@ProductLine nchar(2) = null,
	@Availability bit = 1 -- Stock Availability
AS
BEGIN
	IF @Availability = 1
	BEGIN
		-- Only category received | STOCK AVAILABLE
		IF @Category IS NOT NULL AND @Subcategory IS NULL AND @Size IS NULL AND @Style IS NULL AND @Class IS NULL AND @ProductLine IS NULL
		BEGIN
			SELECT DISTINCT Production.ProductModel.Name, Production.ProductDescription.Description
			FROM Production.Product
			INNER JOIN Production.ProductSubcategory ON Production.Product.ProductSubcategoryID = Production.ProductSubcategory.ProductSubcategoryID 
			INNER JOIN Production.ProductCategory ON Production.ProductSubcategory.ProductCategoryID = Production.ProductCategory.ProductCategoryID 
			INNER JOIN Production.ProductModel ON Production.Product.ProductModelID = Production.ProductModel.ProductModelID 
			INNER JOIN Production.ProductModelProductDescriptionCulture ON Production.ProductModel.ProductModelID = Production.ProductModelProductDescriptionCulture.ProductModelID 
			INNER JOIN Production.ProductDescription ON Production.ProductModelProductDescriptionCulture.ProductDescriptionID = Production.ProductDescription.ProductDescriptionID 
			WHERE ProductModelProductDescriptionCulture.CultureID = @Idioma AND Product.ProductModelID IS NOT NULL 
			AND Production.ProductSubcategory.ProductCategoryID = (SELECT Production.ProductCategory.ProductCategoryID FROM Production.ProductCategory WHERE Production.ProductCategory.Name = @Category)
			AND Production.Product.SellEndDate IS NULL;
		END

		-- Category and Subcategory received | STOCK AVAILABLE
		IF @Category IS NOT NULL AND @Subcategory IS NOT NULL AND @Size IS NULL AND @Style IS NULL AND @Class IS NULL AND @ProductLine IS NULL
		BEGIN
			SELECT DISTINCT Production.ProductModel.Name, Production.ProductDescription.Description
			FROM Production.Product
			INNER JOIN Production.ProductSubcategory ON Production.Product.ProductSubcategoryID = Production.ProductSubcategory.ProductSubcategoryID 
			INNER JOIN Production.ProductCategory ON Production.ProductSubcategory.ProductCategoryID = Production.ProductCategory.ProductCategoryID 
			INNER JOIN Production.ProductModel ON Production.Product.ProductModelID = Production.ProductModel.ProductModelID 
			INNER JOIN Production.ProductModelProductDescriptionCulture ON Production.ProductModel.ProductModelID = Production.ProductModelProductDescriptionCulture.ProductModelID 
			INNER JOIN Production.ProductDescription ON Production.ProductModelProductDescriptionCulture.ProductDescriptionID = Production.ProductDescription.ProductDescriptionID 
			WHERE ProductModelProductDescriptionCulture.CultureID = @Idioma AND Product.ProductModelID IS NOT NULL 
			AND Production.ProductSubcategory.ProductCategoryID = (SELECT Production.ProductCategory.ProductCategoryID FROM Production.ProductCategory WHERE Production.ProductCategory.Name = @Category)
			AND Production.ProductSubcategory.Name = @Subcategory
			AND Production.Product.SellEndDate IS NULL;
		END

		-- Category, Subcategory and Size received | STOCK AVAILABLE
		IF @Category IS NOT NULL AND @Subcategory IS NOT NULL AND @Size IS NOT NULL AND @Style IS NULL AND @Class IS NULL AND @ProductLine IS NULL
		BEGIN
			SELECT DISTINCT Production.ProductModel.Name, Production.ProductDescription.Description
			FROM Production.Product
			INNER JOIN Production.ProductSubcategory ON Production.Product.ProductSubcategoryID = Production.ProductSubcategory.ProductSubcategoryID 
			INNER JOIN Production.ProductCategory ON Production.ProductSubcategory.ProductCategoryID = Production.ProductCategory.ProductCategoryID 
			INNER JOIN Production.ProductModel ON Production.Product.ProductModelID = Production.ProductModel.ProductModelID 
			INNER JOIN Production.ProductModelProductDescriptionCulture ON Production.ProductModel.ProductModelID = Production.ProductModelProductDescriptionCulture.ProductModelID 
			INNER JOIN Production.ProductDescription ON Production.ProductModelProductDescriptionCulture.ProductDescriptionID = Production.ProductDescription.ProductDescriptionID 
			WHERE ProductModelProductDescriptionCulture.CultureID = @Idioma AND Product.ProductModelID IS NOT NULL 
			AND Production.ProductSubcategory.ProductCategoryID = (SELECT Production.ProductCategory.ProductCategoryID FROM Production.ProductCategory WHERE Production.ProductCategory.Name = @Category)
			AND Production.ProductSubcategory.Name = @Subcategory
			AND Production.Product.Size = @Size
			AND Production.Product.SellEndDate IS NULL;
		END

		-- Category, Subcategory and Class received | STOCK Available
		IF @Category IS NOT NULL AND @Subcategory IS NOT NULL AND @Size IS NULL AND @Style IS NULL AND @Class IS NOT NULL AND @ProductLine IS NULL
		BEGIN
			SELECT DISTINCT Production.ProductModel.Name, Production.ProductDescription.Description
			FROM Production.Product
			INNER JOIN Production.ProductSubcategory ON Production.Product.ProductSubcategoryID = Production.ProductSubcategory.ProductSubcategoryID 
			INNER JOIN Production.ProductCategory ON Production.ProductSubcategory.ProductCategoryID = Production.ProductCategory.ProductCategoryID 
			INNER JOIN Production.ProductModel ON Production.Product.ProductModelID = Production.ProductModel.ProductModelID 
			INNER JOIN Production.ProductModelProductDescriptionCulture ON Production.ProductModel.ProductModelID = Production.ProductModelProductDescriptionCulture.ProductModelID 
			INNER JOIN Production.ProductDescription ON Production.ProductModelProductDescriptionCulture.ProductDescriptionID = Production.ProductDescription.ProductDescriptionID 
			WHERE ProductModelProductDescriptionCulture.CultureID = @Idioma AND Product.ProductModelID IS NOT NULL 
			AND Production.ProductSubcategory.ProductCategoryID = (SELECT Production.ProductCategory.ProductCategoryID FROM Production.ProductCategory WHERE Production.ProductCategory.Name = @Category)
			AND Production.ProductSubcategory.Name = @Subcategory
			AND Production.Product.Class = @Class
			AND Production.Product.SellEndDate IS NULL;
		END

		-- Category, Subcategory and Style received | STOCK Available
		IF @Category IS NOT NULL AND @Subcategory IS NOT NULL AND @Size IS NULL AND @Style IS NOT NULL AND @Class IS NULL AND @ProductLine IS NULL
		BEGIN
			SELECT DISTINCT Production.ProductModel.Name, Production.ProductDescription.Description
			FROM Production.Product
			INNER JOIN Production.ProductSubcategory ON Production.Product.ProductSubcategoryID = Production.ProductSubcategory.ProductSubcategoryID 
			INNER JOIN Production.ProductCategory ON Production.ProductSubcategory.ProductCategoryID = Production.ProductCategory.ProductCategoryID 
			INNER JOIN Production.ProductModel ON Production.Product.ProductModelID = Production.ProductModel.ProductModelID 
			INNER JOIN Production.ProductModelProductDescriptionCulture ON Production.ProductModel.ProductModelID = Production.ProductModelProductDescriptionCulture.ProductModelID 
			INNER JOIN Production.ProductDescription ON Production.ProductModelProductDescriptionCulture.ProductDescriptionID = Production.ProductDescription.ProductDescriptionID 
			WHERE ProductModelProductDescriptionCulture.CultureID = @Idioma AND Product.ProductModelID IS NOT NULL 
			AND Production.ProductSubcategory.ProductCategoryID = (SELECT Production.ProductCategory.ProductCategoryID FROM Production.ProductCategory WHERE Production.ProductCategory.Name = @Category)
			AND Production.ProductSubcategory.Name = @Subcategory
			AND Production.Product.Style = @Style
			AND Production.Product.SellEndDate IS NULL;
		END

		-- Category, Subcategory and ProductLine received | STOCK Avaiable
		IF @Category IS NOT NULL AND @Subcategory IS NOT NULL AND @Size IS NULL AND @Style IS NULL AND @Class IS NULL AND @ProductLine IS NOT NULL
		BEGIN
			SELECT DISTINCT Production.ProductModel.Name, Production.ProductDescription.Description
			FROM Production.Product
			INNER JOIN Production.ProductSubcategory ON Production.Product.ProductSubcategoryID = Production.ProductSubcategory.ProductSubcategoryID 
			INNER JOIN Production.ProductCategory ON Production.ProductSubcategory.ProductCategoryID = Production.ProductCategory.ProductCategoryID 
			INNER JOIN Production.ProductModel ON Production.Product.ProductModelID = Production.ProductModel.ProductModelID 
			INNER JOIN Production.ProductModelProductDescriptionCulture ON Production.ProductModel.ProductModelID = Production.ProductModelProductDescriptionCulture.ProductModelID 
			INNER JOIN Production.ProductDescription ON Production.ProductModelProductDescriptionCulture.ProductDescriptionID = Production.ProductDescription.ProductDescriptionID 
			WHERE ProductModelProductDescriptionCulture.CultureID = @Idioma AND Product.ProductModelID IS NOT NULL 
			AND Production.ProductSubcategory.ProductCategoryID = (SELECT Production.ProductCategory.ProductCategoryID FROM Production.ProductCategory WHERE Production.ProductCategory.Name = @Category)
			AND Production.ProductSubcategory.Name = @Subcategory
			AND Production.Product.ProductLine = @ProductLine
			AND Production.Product.SellEndDate IS NULL;
		END
	END
	IF @Availability = 0
	BEGIN
		-- Only category received | STOCK AVAILABLE
		IF @Category IS NOT NULL AND @Subcategory IS NULL AND @Size IS NULL AND @Style IS NULL AND @Class IS NULL AND @ProductLine IS NULL
		BEGIN
			SELECT DISTINCT Production.ProductModel.Name, Production.ProductDescription.Description
			FROM Production.Product
			INNER JOIN Production.ProductSubcategory ON Production.Product.ProductSubcategoryID = Production.ProductSubcategory.ProductSubcategoryID 
			INNER JOIN Production.ProductCategory ON Production.ProductSubcategory.ProductCategoryID = Production.ProductCategory.ProductCategoryID 
			INNER JOIN Production.ProductModel ON Production.Product.ProductModelID = Production.ProductModel.ProductModelID 
			INNER JOIN Production.ProductModelProductDescriptionCulture ON Production.ProductModel.ProductModelID = Production.ProductModelProductDescriptionCulture.ProductModelID 
			INNER JOIN Production.ProductDescription ON Production.ProductModelProductDescriptionCulture.ProductDescriptionID = Production.ProductDescription.ProductDescriptionID 
			WHERE ProductModelProductDescriptionCulture.CultureID = @Idioma AND Product.ProductModelID IS NOT NULL 
			AND Production.ProductSubcategory.ProductCategoryID = (SELECT Production.ProductCategory.ProductCategoryID FROM Production.ProductCategory WHERE Production.ProductCategory.Name = @Category);
		END

		-- Category and Subcategory received | STOCK AVAILABLE
		IF @Category IS NOT NULL AND @Subcategory IS NOT NULL AND @Size IS NULL AND @Style IS NULL AND @Class IS NULL AND @ProductLine IS NULL
		BEGIN
			SELECT DISTINCT Production.ProductModel.Name, Production.ProductDescription.Description
			FROM Production.Product
			INNER JOIN Production.ProductSubcategory ON Production.Product.ProductSubcategoryID = Production.ProductSubcategory.ProductSubcategoryID 
			INNER JOIN Production.ProductCategory ON Production.ProductSubcategory.ProductCategoryID = Production.ProductCategory.ProductCategoryID 
			INNER JOIN Production.ProductModel ON Production.Product.ProductModelID = Production.ProductModel.ProductModelID 
			INNER JOIN Production.ProductModelProductDescriptionCulture ON Production.ProductModel.ProductModelID = Production.ProductModelProductDescriptionCulture.ProductModelID 
			INNER JOIN Production.ProductDescription ON Production.ProductModelProductDescriptionCulture.ProductDescriptionID = Production.ProductDescription.ProductDescriptionID 
			WHERE ProductModelProductDescriptionCulture.CultureID = @Idioma AND Product.ProductModelID IS NOT NULL 
			AND Production.ProductSubcategory.ProductCategoryID = (SELECT Production.ProductCategory.ProductCategoryID FROM Production.ProductCategory WHERE Production.ProductCategory.Name = @Category)
			AND Production.ProductSubcategory.Name = @Subcategory;
		END

		-- Category, Subcategory and Size received | STOCK AVAILABLE
		IF @Category IS NOT NULL AND @Subcategory IS NOT NULL AND @Size IS NOT NULL AND @Style IS NULL AND @Class IS NULL AND @ProductLine IS NULL
		BEGIN
			SELECT DISTINCT Production.ProductModel.Name, Production.ProductDescription.Description
			FROM Production.Product
			INNER JOIN Production.ProductSubcategory ON Production.Product.ProductSubcategoryID = Production.ProductSubcategory.ProductSubcategoryID 
			INNER JOIN Production.ProductCategory ON Production.ProductSubcategory.ProductCategoryID = Production.ProductCategory.ProductCategoryID 
			INNER JOIN Production.ProductModel ON Production.Product.ProductModelID = Production.ProductModel.ProductModelID 
			INNER JOIN Production.ProductModelProductDescriptionCulture ON Production.ProductModel.ProductModelID = Production.ProductModelProductDescriptionCulture.ProductModelID 
			INNER JOIN Production.ProductDescription ON Production.ProductModelProductDescriptionCulture.ProductDescriptionID = Production.ProductDescription.ProductDescriptionID 
			WHERE ProductModelProductDescriptionCulture.CultureID = @Idioma AND Product.ProductModelID IS NOT NULL 
			AND Production.ProductSubcategory.ProductCategoryID = (SELECT Production.ProductCategory.ProductCategoryID FROM Production.ProductCategory WHERE Production.ProductCategory.Name = @Category)
			AND Production.ProductSubcategory.Name = @Subcategory
			AND Production.Product.Size = @Size;
		END

		-- Category, Subcategory and Class received | STOCK Available
		IF @Category IS NOT NULL AND @Subcategory IS NOT NULL AND @Size IS NULL AND @Style IS NULL AND @Class IS NOT NULL AND @ProductLine IS NULL
		BEGIN
			SELECT DISTINCT Production.ProductModel.Name, Production.ProductDescription.Description
			FROM Production.Product
			INNER JOIN Production.ProductSubcategory ON Production.Product.ProductSubcategoryID = Production.ProductSubcategory.ProductSubcategoryID 
			INNER JOIN Production.ProductCategory ON Production.ProductSubcategory.ProductCategoryID = Production.ProductCategory.ProductCategoryID 
			INNER JOIN Production.ProductModel ON Production.Product.ProductModelID = Production.ProductModel.ProductModelID 
			INNER JOIN Production.ProductModelProductDescriptionCulture ON Production.ProductModel.ProductModelID = Production.ProductModelProductDescriptionCulture.ProductModelID 
			INNER JOIN Production.ProductDescription ON Production.ProductModelProductDescriptionCulture.ProductDescriptionID = Production.ProductDescription.ProductDescriptionID 
			WHERE ProductModelProductDescriptionCulture.CultureID = @Idioma AND Product.ProductModelID IS NOT NULL 
			AND Production.ProductSubcategory.ProductCategoryID = (SELECT Production.ProductCategory.ProductCategoryID FROM Production.ProductCategory WHERE Production.ProductCategory.Name = @Category)
			AND Production.ProductSubcategory.Name = @Subcategory
			AND Production.Product.Class = @Class;
		END

		-- Category, Subcategory and Style received | STOCK Available
		IF @Category IS NOT NULL AND @Subcategory IS NOT NULL AND @Size IS NULL AND @Style IS NOT NULL AND @Class IS NULL AND @ProductLine IS NULL
		BEGIN
			SELECT DISTINCT Production.ProductModel.Name, Production.ProductDescription.Description
			FROM Production.Product
			INNER JOIN Production.ProductSubcategory ON Production.Product.ProductSubcategoryID = Production.ProductSubcategory.ProductSubcategoryID 
			INNER JOIN Production.ProductCategory ON Production.ProductSubcategory.ProductCategoryID = Production.ProductCategory.ProductCategoryID 
			INNER JOIN Production.ProductModel ON Production.Product.ProductModelID = Production.ProductModel.ProductModelID 
			INNER JOIN Production.ProductModelProductDescriptionCulture ON Production.ProductModel.ProductModelID = Production.ProductModelProductDescriptionCulture.ProductModelID 
			INNER JOIN Production.ProductDescription ON Production.ProductModelProductDescriptionCulture.ProductDescriptionID = Production.ProductDescription.ProductDescriptionID 
			WHERE ProductModelProductDescriptionCulture.CultureID = @Idioma AND Product.ProductModelID IS NOT NULL 
			AND Production.ProductSubcategory.ProductCategoryID = (SELECT Production.ProductCategory.ProductCategoryID FROM Production.ProductCategory WHERE Production.ProductCategory.Name = @Category)
			AND Production.ProductSubcategory.Name = @Subcategory
			AND Production.Product.Style = @Style;
		END

		-- Category, Subcategory and ProductLine received | STOCK Avaiable
		IF @Category IS NOT NULL AND @Subcategory IS NOT NULL AND @Size IS NULL AND @Style IS NULL AND @Class IS NULL AND @ProductLine IS NOT NULL
		BEGIN
			SELECT DISTINCT Production.ProductModel.Name, Production.ProductDescription.Description
			FROM Production.Product
			INNER JOIN Production.ProductSubcategory ON Production.Product.ProductSubcategoryID = Production.ProductSubcategory.ProductSubcategoryID 
			INNER JOIN Production.ProductCategory ON Production.ProductSubcategory.ProductCategoryID = Production.ProductCategory.ProductCategoryID 
			INNER JOIN Production.ProductModel ON Production.Product.ProductModelID = Production.ProductModel.ProductModelID 
			INNER JOIN Production.ProductModelProductDescriptionCulture ON Production.ProductModel.ProductModelID = Production.ProductModelProductDescriptionCulture.ProductModelID 
			INNER JOIN Production.ProductDescription ON Production.ProductModelProductDescriptionCulture.ProductDescriptionID = Production.ProductDescription.ProductDescriptionID 
			WHERE ProductModelProductDescriptionCulture.CultureID = @Idioma AND Product.ProductModelID IS NOT NULL 
			AND Production.ProductSubcategory.ProductCategoryID = (SELECT Production.ProductCategory.ProductCategoryID FROM Production.ProductCategory WHERE Production.ProductCategory.Name = @Category)
			AND Production.ProductSubcategory.Name = @Subcategory
			AND Production.Product.ProductLine = @ProductLine;
		END
	END
END