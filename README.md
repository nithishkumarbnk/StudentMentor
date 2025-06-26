# StudentMentor

A web application designed to manage student and mentor information efficiently. This project allows adding students, creating mentors, assigning students to mentors, and updating mentor-student relationships.

## 📂 Project Structure

- `db.js` - Database connection setup using MongoDB.
- `index.js` - Main server file handling API routes and server initialization.
- `routes/mentor.js` - API endpoints related to mentors.
- `routes/student.js` - API endpoints related to students.
- `package.json` - Contains project metadata and dependencies.

## ⚙️ Built With

- **Node.js** - JavaScript runtime environment.
- **Express.js** - Web framework for Node.js.
- **MongoDB** - NoSQL database for storing student and mentor data.
- **Mongoose** - ODM (Object Data Modeling) library for MongoDB and Node.js.

## 🚀 How to Run Locally

Follow these steps to run the project on your local machine:

1. Clone the repository
   ```bash
   git clone https://github.com/nithishkumarbnk/StudentMentor.git
2. Navigate into the project directory
   cd StudentMentor
3. Install the dependencies
   npm install
4. Start the server
   npm start
5.The server will usually run at http://localhost:3000.

📚 API Endpoints
Student APIs
POST /student — Create a new student

PUT /student/assignMentor/:studentId — Assign or change mentor for a student

GET /student/previousMentor/:studentId — Get previous mentor history for a student

Mentor APIs
POST /mentor — Create a new mentor

PUT /mentor/assignStudents/:mentorId — Assign multiple students to a mentor

GET /mentor/students/:mentorId — Get all students assigned to a particular mentor

✨ Features
Create and manage students and mentors.

Assign mentors to students and reassign when needed.

Track previous mentors of a student.

View all students assigned to a particular mentor.

🛡️ License
This project is licensed under the MIT License.

🙌 Acknowledgements
Thanks to the open-source community for providing great tools and libraries.
