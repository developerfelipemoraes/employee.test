import React from "react";
import { Routes, Route } from "react-router-dom";
import Login from "./pages/Login";
import EmployeeList from "./pages/EmployeeList";
import EmployeeForm from "./pages/EmployeeForm";
import PrivateRoute from "./routes/PrivateRoute";

function App() {
  return (
    <Routes>
      <Route path="/" element={<Login />} />
      <Route path="/employees" element={<PrivateRoute><EmployeeList /></PrivateRoute>} />
      <Route path="/employees/new" element={<PrivateRoute><EmployeeForm /></PrivateRoute>} />
    </Routes>
  );
}

export default App;