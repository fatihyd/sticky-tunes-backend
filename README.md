# StickyTunes Backend API

StickyTunes is an anonymous Spotify song-sharing platform that allows users to post Spotify track URLs and share comments on songs.

## Technologies Used

- **ASP.NET Core 8.0**
- **Entity Framework Core**
- **MySQL** (Database)
- **AutoMapper** (DTO Mapping)
- **Spotify Web API**

## Setup

### Prerequisites

- .NET SDK 8.0+
- MySQL
- Spotify Developer Account
- Postman (optional for testing)

### Configuration

1. Clone the repository:

    ```bash
    git clone https://github.com/fatihyd/sticky-tunes-backend.git
    cd stickytunes-backend
    ```

2. Update `appsettings.json`:

    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=your-server;Database=stickytunes;User=dbadmin;Password=your-password;"
      },
      "Spotify": {
        "ClientId": "your-client-id",
        "ClientSecret": "your-client-secret"
      },
      "AllowedHosts": "*"
    }
    ```

3. Run migrations and update the database:

    ```bash
    dotnet ef database update
    ```

4. Run the project:

    ```bash
    dotnet run
    ```

## Endpoints

### Posts

- `GET /api/posts` - Get all posts.
- `GET /api/posts/{id}` - Get post by ID.
- `POST /api/posts` - Create a new post with a Spotify song.
- `DELETE /api/posts/{id}` - Delete a post and associated comments.

### Comments

- `GET /api/posts/{postId}/comments` - Get all comments for a post.
- `GET /api/posts/{postId}/comments/{commentId}` - Get a comment by ID.
- `POST /api/posts/{postId}/comments` - Add a comment with a Spotify song.
- `DELETE /api/posts/{postId}/comments/{commentId}` - Delete a comment.
