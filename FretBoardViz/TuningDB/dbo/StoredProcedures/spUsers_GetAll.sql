CREATE PROCEDURE [dbo].[spUsers_GetAll]
AS
BEGIN
	SELECT UserId, Username, Email
	FROM dbo.[Users]
END
