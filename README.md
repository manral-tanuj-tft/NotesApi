## Objective
Build a minimal **ASP.NET Core Web API** to manage notes.  
You may use AI tools to assist, but your **code must run** and meet all requirements.

---

## Requirements

### **1. Endpoints**
- **POST /notes** → Add a new note  
  - Title: required, max 100 chars  
  - Content: optional  
  - CreatedAt: auto-set  
- **GET /notes** → List all notes  
- **GET /notes/{id}** → Get a note by ID  
- **DELETE /notes/{id}** → Delete a note  

---

### **2. Technical Constraints**
- .NET **6+** or **7+**  
- ASP.NET Core Web API  
- **Entity Framework Core InMemory** database  
- Proper HTTP status codes:  
  - **201 Created** (new note)  
  - **200 OK** (get/delete)  
  - **404 Not Found** (missing note)  
  - **400 Bad Request** (validation errors)

---

### **3. Bonus (Optional)**
- **PUT /notes/{id}** → Update a note  
- Filtering in `GET /notes` by keyword  
- Swagger/OpenAPI documentation  

---

## Example Input / Output

### **Create Note – POST /notes**

**Request**
```json
{
  "title": "First Note",
  "content": "This is my first note."
}
```

**Response – 201 Created**
```json
{
  "id": 1,
  "title": "First Note",
  "content": "This is my first note.",
  "createdAt": "2025-08-13T14:35:22Z"
}
```

---

### **Get All Notes – GET /notes**

**Response – 200 OK**
```json
[
  {
    "id": 1,
    "title": "First Note",
    "content": "This is my first note.",
    "createdAt": "2025-08-13T14:35:22Z"
  }
]
```

---

### **Get Note by ID – GET /notes/99**

**Response – 404 Not Found**
```json
{
  "message": "Note not found."
}
```

---

### **Delete Note – DELETE /notes/1**

**Response – 200 OK**
```json
{
  "message": "Note deleted successfully."
}
```

---

## How to Run

```
dotnet restore
dotnet run

OR 
Use visual studio RUN
```

API will run at:

```
https://localhost:xxxx
```

Swagger (if enabled):

```
https://localhost:xxxx/swagger
