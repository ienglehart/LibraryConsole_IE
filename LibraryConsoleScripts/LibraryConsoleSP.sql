USE [LibraryConsole]
GO

/****** Object:  StoredProcedure [dbo].[CreateUser]    Script Date: 4/26/2022 4:52:28 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateUser]
	-- Add the parameters for the stored procedure here
	@ID int,
	@name varchar(50),
	@username varchar(50),
	@password varchar(150),
	@role_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Users( Users.user_id, Users.name, Users.username, Users.password, Users.role_id)
	VALUES(@ID, @name, @username, @password, @role_id);
END
GO

USE [LibraryConsole]
GO

/****** Object:  StoredProcedure [dbo].[deleteUser]    Script Date: 4/26/2022 4:54:32 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[deleteUser]
	-- Add the parameters for the stored procedure here
	@user varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM Users
	WHERE @user = Users.username;
END
GO

USE [LibraryConsole]
GO

/****** Object:  StoredProcedure [dbo].[editUser]    Script Date: 4/26/2022 4:55:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[editUser]
	-- Add the parameters for the stored procedure here
	@username varchar(50),
	@updated varchar(50),
	@changes varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Users
	SET @updated = @changes
	WHERE @username = Users.username;
END
GO

USE [LibraryConsole]
GO

/****** Object:  StoredProcedure [dbo].[readAllUsers]    Script Date: 4/26/2022 4:56:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[readAllUsers]
	-- Add the parameters for the stored procedure here

	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT name, username, role_id
	FROM Users;
END
GO

USE [LibraryConsole]
GO

/****** Object:  StoredProcedure [dbo].[readByID]    Script Date: 4/26/2022 4:57:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[readByID]
	-- Add the parameters for the stored procedure here
	@user_id int
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT *
	FROM Users
	WHERE @user_id = Users.user_id;
END
GO

USE [LibraryConsole]
GO

/****** Object:  StoredProcedure [dbo].[readByUsername]    Script Date: 4/26/2022 4:57:44 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[readByUsername]
	-- Add the parameters for the stored procedure here
	@username varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT *
	FROM Users
	WHERE @username = Users.username;
END
GO


