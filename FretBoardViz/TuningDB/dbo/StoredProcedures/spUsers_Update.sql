CREATE PROCEDURE [dbo].[spUsers_Update]
    @UserId INT,
    @NewUsername NVARCHAR(50),
    @NewPasswordHash NVARCHAR(255),
    @NewEmail NVARCHAR(100)
AS
BEGIN
    -- Check if the @UserId exists
    IF EXISTS (SELECT 1 FROM [dbo].[Users] WHERE UserId = @UserId)
    BEGIN
        -- Update the user's information
        UPDATE [dbo].[Users]
        SET Username = @NewUsername,
            PasswordHash = @NewPasswordHash,
            Email = @NewEmail
        WHERE UserId = @UserId;

        -- Return a success status or message
        SELECT 'User information updated successfully' AS [Status];
    END
    ELSE
    BEGIN
        -- Return an error status or message if the user doesn't exist
        SELECT 'User not found. Update operation failed' AS [Status];
    END
END