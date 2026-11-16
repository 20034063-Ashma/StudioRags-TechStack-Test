import { Link } from "react-router-dom";

export default function PaymentCancelled() {
  return (
    <div style={{ maxWidth: 480, margin: "3rem auto", textAlign: "center" }}>
      <h1>Payment cancelled</h1>
      <p>No money was taken. You can try again whenever you're ready.</p>
      <Link to="/">Back to home</Link>
    </div>
  );
}
