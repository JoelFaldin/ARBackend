# Unity AR Backend – ASP.NET Core API

![C# Logo](https://imgs.search.brave.com/Da8GaIZ1MoeZ2k7OqPivW8IdROzvMVmBqruYVVmzfXM/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly9keW1h/LmZyL2Jsb2cvY29u/dGVudC9pbWFnZXMv/c2l6ZS93OTYwLzIw/MjQvMDgvY3NoYXJw/MTIwMHg2Mjgud2Vi/cA)

This project is the backend part for an **Augmented Reality Unity project**, built with C# and ASP.NET Core.
Featuring **registration**, **login with JWT authentication**, and manages additional user-specific data.

## 🔧 Features

- User Registration & Login
- JWT-based Authentication
- RESTful API endpoints
- Extra Data Table for user-related content
- Dockerized Deployment
- Hosted on [Render](https://render.com/)
- PostgreSQL Database (also hosted on Render)

---

## 📦 Tech Stack

<div align="center">

  ![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
  ![Postgres](https://img.shields.io/badge/postgres-%23316192.svg?style=for-the-badge&logo=postgresql&logoColor=white)
  ![Docker](https://img.shields.io/badge/docker-%230db7ed.svg?style=for-the-badge&logo=docker&logoColor=white)
  ![Render](https://img.shields.io/badge/Render-%46E3B7.svg?style=for-the-badge&logo=render&logoColor=white)
  
</div>
<div align="center">
  
  ![Unity](https://img.shields.io/badge/unity-%23000000.svg?style=for-the-badge&logo=unity&logoColor=white)
  
</div>

Other things used:

- **Auth**: JWT Bearer Token
- **ORM**: Entity Framework Core

---

## 🛠 Setup Instructions

### 1. Clone the Repo

```bash
git clone https://github.com/JoelFaldin/ARBackend.git
cd ARBackend
```

### 2. Set up environment variables

```bash
JWT_SECRET=your_super_secret_key
DB_CONNECTION=Host=your-db-host;Port=5432;Database=your-db-name;Username=your-user;Password=your-password;
```

### 3. Build and run using docker:

```bash
docker build -t unity-ar-backend .
docker run -p 5000:80 unity-ar-backend
```

## 🚀 Deployment
This project is deployed using Render:

- ✅ Backend API
  - Docker container deployed from this repo
  - Exposes a public API endpoint for the Unity client

- ✅ PostgreSQL Database
  - PostgreSQL instance created through Render's managed services
  - Connection string used in the backend via environment variables

---

Thanks for visiting!

![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
