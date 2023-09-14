CREATE PROCEDURE [dbo].[spUsers_Delete]
	@Id int
AS	
BEGIN
	DELETE
	FROM dbo.[Users]
	WHERE UserId = @Id
END
