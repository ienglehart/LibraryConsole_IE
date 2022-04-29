USE [LibraryConsole]
GO

/****** Object:  StoredProcedure [dbo].[ExceptionLogger]    Script Date: 4/29/2022 5:28:52 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create Procedure [dbo].[ExceptionLogger]
(  
@ExceptionMsg varchar(100)=null,  
@ExceptionType varchar(100)=null,  
@ExceptionSource nvarchar(max)=null,  
@ExceptionURL varchar(100)=null  
)  
as  
begin  
Insert into ExceptionLogging 
(  
ExceptionMsg ,  
ExceptionType,   
ExceptionSource,  
ExceptionURL,  
Logdate  
)  
select  
@ExceptionMsg,  
@ExceptionType,  
@ExceptionSource,  
@ExceptionURL,  
getdate()  
End 
GO


