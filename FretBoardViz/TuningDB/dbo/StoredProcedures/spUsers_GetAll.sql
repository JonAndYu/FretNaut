CREATE PROCEDURE [dbo].[spUsers_GetAll]
AS
BEGIN
	SELECT UserId, Username, PasswordHash, Email
	FROM dbo.[Users]
END
