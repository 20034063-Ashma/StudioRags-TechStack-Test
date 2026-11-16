import { useEffect, useState } from "react";
import { Link, useSearchParams } from "react-router-dom";
import { API_URL } from "../config";

export default function PaymentSuccess() {
  const [params] = useSearchParams();
  const sessionId = params.get("session_id");
  const [status, setStatus] = useState(null);
  const [error, setError] = useState("");

  useEffect(() => {
    if (!sessionId) return;

    fetch(`${API_URL}/api/payment/session-status?session_id=${encodeURIComponent(sessionId)}`)
      .then((res) => res.json())
      .then((data) => {
        if (data.error) setError(data.error);
        else setStatus(data);
      })
      .catch(() => setError("Could not verify the payment."));
  }, [sessionId]);

  return (
    <div style={{ maxWidth: 480, margin: "3rem auto", textAlign: "center" }}>
      <h1>Payment successful</h1>

      {!sessionId && <p>No payment session found.</p>}
      {error && <p style={{ color: "crimson" }}>{error}</p>}

      {status && (
        <p>
          Status: <strong>{status.paymentStatus}</strong>
          <br />
          Amount: {(status.amountTotal / 100).toFixed(2)} {status.currency?.toUpperCase()}
        </p>
      )}

      <Link to="/">Back to home</Link>
    </div>
  );
}
