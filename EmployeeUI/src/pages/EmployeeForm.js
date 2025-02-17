import React, { useEffect, useState } from "react";
import { createEmployee, updateEmployee, getEmployeeById } from "../services/employeeService";
import { useNavigate, useParams } from "react-router-dom";

export default function EmployeeForm() {
    const [formData, setFormData] = useState({
        firstName: "",
        lastName: "",
        email: "",
        docNumber: "",
        phones: "",
        password: ""
    });
    const navigate = useNavigate();
    const { id } = useParams();

    useEffect(() => {
        if (id) {
            loadEmployee();
        }
    }, [id]);

    const loadEmployee = async () => {
        const data = await getEmployeeById(id);
        setFormData(data);
    };

    const handleChange = (e) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        if (id) {
            await updateEmployee(id, formData);
        } else {
            await createEmployee(formData);
        }
        navigate("/employees");
    };

    return (
        <div className="container mt-5">
            <h2>{id ? "Edit Employee" : "New Employee"}</h2>
            <form onSubmit={handleSubmit}>
                <input type="text" name="firstName" placeholder="First Name" value={formData.firstName} onChange={handleChange} required className="form-control my-2" />
                <input type="text" name="lastName" placeholder="Last Name" value={formData.lastName} onChange={handleChange} required className="form-control my-2" />
                <input type="email" name="email" placeholder="Email" value={formData.email} onChange={handleChange} required className="form-control my-2" />
                <input type="text" name="docNumber" placeholder="Document Number" value={formData.docNumber} onChange={handleChange} required className="form-control my-2" />
                <input type="text" name="phones" placeholder="Phones (comma separated)" value={formData.phones} onChange={handleChange} required className="form-control my-2" />
                <input type="password" name="password" placeholder="Password" value={formData.password} onChange={handleChange} required className="form-control my-2" />
                <button type="submit" className="btn btn-primary">{id ? "Update" : "Create"}</button>
            </form>
        </div>
    );
}