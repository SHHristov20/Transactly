import React, { useRef } from "react";
import axios from "axios";
import { useNavigate } from "react-router";
import { useUserContext } from "./Context/UserContext";

const Deposit = (props) => {
  const { userObject } = useUserContext();
  const navigate = useNavigate();
  const accountIdRef = useRef();
  const amountRef = useRef();
  const cardholderRef = useRef();
  const cardNumberRef = useRef();
  const expiryRef = useRef();
  const cvvRef = useRef();

  const deposit = async () => {
    if (
      !amountRef.current.value ||
      !cardholderRef.current.value ||
      !cardNumberRef.current.value ||
      !expiryRef.current.value ||
      !cvvRef.current.value
    ) {
      alert("Please fill all fields");
      return;
    }

    try {
      const response = await axios.post(
        "http://localhost:5165/Account/Deposit",
        {
          accountId: parseInt(accountIdRef.current.value),
          amount: parseFloat(amountRef.current.value),
          reason: "Deposit",
          cardNumber: cardNumberRef.current.value.toString().trim(),
          expiryDate: expiryRef.current.value,
          cvv: cvvRef.current.value,
        }
      );

      if (response.status === 200) {
        alert("Deposited successfully");
        props.toggleDeposit();
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
          <h1 className="text-2xl font-bold text-center">Deposit Money</h1>

          {/* currency */}
          <select
            className="border-b-[1px] focus:outline-none py-2 w-full mb-4"
            ref={accountIdRef}
          >
            {userObject.accounts.map((account) => (
              <option key={account.id} value={account.id}>
                {account.currency.currencyName}
              </option>
            ))}
          </select>

          <input
            placeholder="Amount"
            className="border-b-[1px] focus:outline-none py-2 w-full mb-4"
            ref={amountRef}
          />

          <input
            placeholder="Cardholder Name"
            className="border-b-[1px] focus:outline-none py-2 w-full mb-4"
            ref={cardholderRef}
          />

          <input
            placeholder="Card Number"
            className="border-b-[1px] focus:outline-none py-2 w-full mb-4"
            maxLength={99}
            ref={cardNumberRef}
          />

          <div className="flex gap-4">
            <input
              placeholder="MM/YY"
              className="border-b-[1px] focus:outline-none py-2 w-1/2"
              maxLength={5}
              ref={expiryRef}
            />
            <input
              placeholder="CVV"
              className="border-b-[1px] focus:outline-none py-2 w-1/2"
              maxLength={3}
              ref={cvvRef}
            />
          </div>

          <div className="flex gap-x-5 mt-5">
            <button
              className="bg-pink-600 text-white rounded-full w-full py-3"
              onClick={deposit}
            >
              Deposit
            </button>
            <button
              className={"bg-gray-200 text-gray-800 rounded-full w-full py-3"}
              onClick={props.toggleDeposit}
            >
              Cancel
            </button>
          </div>
        </div>
      </div>
    </React.Fragment>
  );
};

export default Deposit;
