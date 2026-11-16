import { useState } from "react";
import { API_URL } from "../config";

export default function PayButton() {
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState("");

  const handlePay = async () => {
    setLoading(true);
    setError("");

    try {
      const res = await fetch(`${API_URL}/api/payment/create-checkout-session`, {
        method: "POST",
      });
      const data = await res.json();

      if (!res.ok || !data.url) {
        throw new Error(data.error || "Could not start checkout.");
      }

      window.location.href = data.url; // redirect to Stripe Checkout
    } catch (err) {
      setError(err.message);
      setLoading(false);
    }
  };

  return (
    <div>
      <button onClick={handlePay} disabled={loading}>
        {loading ? "Redirecting to Stripe..." : "Pay AUD $1 (Test)"}
      </button>
      {error && <p style={{ color: "crimson" }}>{error}</p>}
    </div>
  );
}
