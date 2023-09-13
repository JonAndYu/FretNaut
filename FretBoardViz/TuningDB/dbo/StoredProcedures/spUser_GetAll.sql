CREATE PROCEDURE [dbo].[spUser_GetAll]
AS
BEGIN
	SELECT UserId, Username, Email
	FROM dbo.[Users]
END
