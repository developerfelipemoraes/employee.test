import axios from "axios";

const API_URL = "http://localhost:5000/api/employees";

const getAuthHeaders = () => {
    return { headers: { Authorization: `Bearer ${localStorage.getItem("jwtToken")}` } };
};

export const getEmployees = async () => {
    const response = await axios.get(API_URL, getAuthHeaders());
    return response.data;
};

export const getEmployeeById = async (id) => {
    const response = await axios.get(`${API_URL}/${id}`, getAuthHeaders());
    return response.data;
};

export const createEmployee = async (employee) => {
    const response = await axios.post(API_URL, employee, getAuthHeaders());
    return response.data;
};

export const updateEmployee = async (id, employee) => {
    const response = await axios.put(`${API_URL}/${id}`, employee, getAuthHeaders());
    return response.data;
};

export const deleteEmployee = async (id) => {
    await axios.delete(`${API_URL}/${id}`, getAuthHeaders());
};