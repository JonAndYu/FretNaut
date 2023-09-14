CREATE PROCEDURE [dbo].[spUsers_Get]
	@Id int
AS	
BEGIN
	SELECT UserId, Username, PasswordHash, Email
	FROM dbo.[Users]
	WHERE UserId = @Id
END
