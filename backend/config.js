// Vite: set VITE_API_URL in frontend/.env
// Create React App: replace with process.env.REACT_APP_API_URL
export const API_URL = import.meta.env.VITE_API_URL || "https://localhost:7000";
