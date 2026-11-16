
import { useState } from "react";

const API_URL = import.meta.env.VITE_API_URL || "http://localhost:5134";

export default function App() {
  const [backend, setBackend] = useState("Not tested yet");
  const [database, setDatabase] = useState("Not tested yet");

  async function testConnection(endpoint, updateStatus) {
    updateStatus("Checking connection...");

    try {
      const response = await fetch(`${API_URL}${endpoint}`);

      if (!response.ok) {
        throw new Error("Connection failed");
      }

      const data = await response.json();
      updateStatus(data.message);
    } catch {
      updateStatus("Connection failed. Backend may not be running.");
    }
  }

  return (
    <div className="min-h-screen bg-purple-950 text-white">
      <header className="border-b border-purple-700 px-8 py-5">
        <h1 className="text-3xl font-bold text-orange-400">
          Studio Rags
        </h1>
      </header>

      <main className="mx-auto max-w-3xl px-6 py-20 text-center">
        <p className="text-orange-400 font-semibold">
          TECHNOLOGY STACK TEST
        </p>

        <h2 className="mt-5 text-5xl font-bold">
          Welcome to Studio Rags
        </h2>

        <p className="mt-6 text-lg text-purple-200">
          A simple website to test our React, ASP.NET Core,
          SQL Server, authentication, Stripe and Azure technologies.
        </p>

        <div className="mt-10 flex flex-wrap justify-center gap-4">
          <button
            onClick={() =>
              testConnection("/api/hello", setBackend)
            }
            className="rounded-lg bg-orange-500 px-6 py-3 font-semibold text-black hover:bg-orange-400"
          >
            Test Backend
          </button>

          <button
            onClick={() =>
              testConnection("/api/database-test", setDatabase)
            }
            className="rounded-lg bg-purple-600 px-6 py-3 font-semibold hover:bg-purple-500"
          >
            Test Database
          </button>
        </div>

        <div className="mt-10 rounded-xl border border-purple-700 bg-purple-900 p-6 text-left">
          <h3 className="mb-4 text-xl font-semibold">
            Connection Status
          </h3>

          <p className="mb-3">
            <strong>Backend:</strong> {backend}
          </p>

          <p>
            <strong>Database:</strong> {database}
          </p>
        </div>
      </main>

      <footer className="border-t border-purple-700 py-6 text-center text-sm text-purple-300">
        Studio Rags | ICT302 Technology Stack Testing
      </footer>
    </div>
  );
}
