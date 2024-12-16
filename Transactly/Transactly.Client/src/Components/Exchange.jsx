import React, { useRef } from "react";
import { useUserContext } from "./Context/UserContext";
import axios from "axios";
import { useNavigate } from "react-router";

const Exchange = (props) => {
  const { userObject, token } = useUserContext();
  const navigate = useNavigate();
  const fromAccountRef = useRef();
  const toAccountRef = useRef();
  const amountRef = useRef();

  const exchangeFunds = async () => {
    if (
      !fromAccountRef.current.value ||
      !toAccountRef.current.value ||
      !amountRef.current.value ||
      fromAccountRef.current.value === toAccountRef.current.value
    ) {
      alert("Please fill all fields");
      return;
    }

    try {
      const response = await axios.post(
        "http://localhost:5165/Account/Exchange",
        {
          token: token,
          fromCurrencyId: fromAccountRef.current.value,
          toCurrencyId: toAccountRef.current.value,
          amount: parseFloat(amountRef.current.value),
        }
      );

      if (response.status === 200) {
        alert("Exchanged successfully");
        props.toggleExchange();
        navigate("/");
      }
    } catch (error) {
      alert(error.response.data.message);
    }
  };
  return (
    <React.Fragment>
      <div className="fixed inset-0 bg-black bg-opacity-50 flex justify-center items-center">
        <div className="bg-white p-6 w-96 rounded-lg">
          <h1 className="text-2xl font-bold text-center">Exchange funds</h1>

          <select className="w-full py-3 mt-5" ref={fromAccountRef}>
            <option value="">Select currency to exchange</option>
            {userObject.accounts.map((account) => (
              <option key={account.id} value={account.currency.id}>
                {account.currency.currencyCode}
              </option>
            ))}
          </select>

          <select className="w-full py-3 mt-5" ref={toAccountRef}>
            <option value="">Select currency to receive</option>
            {userObject.accounts.map((account) => (
              <option key={account.id} value={account.currency.id}>
                {account.currency.currencyCode}
              </option>
            ))}
          </select>

          <input
            type="number"
            placeholder="Amount"
            className="w-full py-3 mt-5"
            ref={amountRef}
          />

          <div className="flex gap-x-5 mt-5">
            <button
              className="bg-pink-600 text-white rounded-full w-full py-3"
              onClick={() => exchangeFunds()}
            >
              Exchange
            </button>
            <button
              className={"bg-gray-200 text-gray-800 rounded-full w-full py-3"}
              onClick={props.toggleExchange}
            >
              Close
            </button>
          </div>
        </div>
      </div>
    </React.Fragment>
  );
};

export default Exchange;
