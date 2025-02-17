import React, { useState, useRef } from "react";
import axios from "axios";
import { useUserContext } from "./Context/UserContext";
import { useNavigate } from "react-router";

const Transfer = (props) => {
  const [option, setOption] = useState("");
  const inputRef = useRef();
  const amountRef = useRef();
  const accountIdRef = useRef();
  const { token, userObject } = useUserContext();
  const navigate = useNavigate();

  const submitTransfer = async () => {
    try {
      const dynamicKey = `to${option}`;
      const response = await axios.post(
        "http://localhost:5165/Account/Transfer",
        {
          token: token,
          fromAccountId: parseInt(accountIdRef.current.value),
          [dynamicKey]: inputRef.current?.value,
          amount: parseFloat(amountRef.current?.value),
        }
      );
      alert("Transfer successful");
      navigate("/");
    } catch (error) {
      alert(error.response.data.message);
    }
  };

  return (
    <React.Fragment>
      <div className="fixed inset-0 bg-black bg-opacity-50 flex justify-center items-center">
        <div className="bg-white p-6 w-96 rounded-lg">
          <h1 className="text-2xl font-bold text-center">Transfer funds</h1>

          <select
            className="w-full py-3 mt-5"
            value={option}
            onChange={(e) => setOption(e.target.value)}
          >
            <option value="">Select transfer option</option>
            <option value="Email">Email</option>
            <option value="AccountNumber">Account number</option>
            <option value="PhoneNumber">Phone number</option>
            <option value="UserTag">User Tag</option>
          </select>

          {option && (
            <input
              type="text"
              placeholder={`Enter ${option}`}
              className="w-full py-3 mt-5"
              ref={inputRef}
            />
          )}

          {option && (
            <select className="w-full py-3 mt-5"
              ref={accountIdRef}
            >
              {userObject.accounts.map((account) => (
                <option key={account.id} value={account.id}>
                  {account.currency.currencyName}
                </option>
              ))}
            </select>
          )}

          {option && (
            <input
              type="number"
              placeholder="Enter amount"
              className="w-full py-3 mt-5"
              ref={amountRef}
            />
          )}

          <div className="flex gap-x-5 mt-5">
            <button
              className="bg-pink-600 text-white rounded-full w-full py-3"
              onClick={submitTransfer}
            >
              Submit transfer
            </button>
            <button
              className="bg-gray-200 text-gray-800 rounded-full w-full py-3"
              onClick={props.toggleTransfer}
            >
              Cancel
            </button>
          </div>
        </div>
      </div>
    </React.Fragment>
  );
};

export default Transfer;
