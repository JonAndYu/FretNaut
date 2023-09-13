CREATE PROCEDURE [dbo].[spUser_Get]
	@Id int
AS	
BEGIN
	SELECT UserId, Username, Email
	FROM dbo.[Users]
	WHERE UserId = @Id
END
