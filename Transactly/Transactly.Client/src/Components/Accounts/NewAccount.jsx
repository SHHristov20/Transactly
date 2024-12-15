import React, { useState, useEffect, useRef } from "react";
import { useUserContext } from "../Context/UserContext";
import axios from "axios";

const NewAccount = (props) => {
  const currencyRef = useRef();
  const [currencies, setCurrencies] = useState([]);

  useEffect(() => {
    console.log("fetching currencies");
    const fetchAllCurrencies = async () => {
      const currencies = await axios.get(
        "http://localhost:5165/Currency/GetAll"
      );
      setCurrencies(currencies);
    };

    fetchAllCurrencies();
  }, []);

  const { userObject } = useUserContext();
  const createAccount = async () => {
    const response = await axios.post("http://localhost:5165/Account/Create", {
      userId: userObject.id,
      currencyId: currencyRef.current.value,
    });

    if (response.status === 200) {
      props.toggleNewAccount();
    }
  };

  return (
    <React.Fragment>
      {currencies.data && (
        <div className="fixed inset-0 bg-black bg-opacity-50 flex justify-center items-center">
          <div className="bg-white p-6 w-96 rounded-lg">
            <h1 className="text-2xl font-bold text-center">Create Account</h1>

            <select
              className="border-b-[1px] focus:outline-none py-2 w-full mb-4"
              ref={currencyRef}
            >
              {currencies.data.map((currency) => (
                <option key={currency.id} value={currency.id}>
                  {currency.currencyName}
                </option>
              ))}
            </select>

            <div className="flex gap-x-5 mt-5">
              <button
                className="bg-pink-600 text-white rounded-full w-full py-3"
                onClick={createAccount}
              >
                Create New Account
              </button>
              <button
                className={"bg-gray-200 text-gray-800 rounded-full w-full py-3"}
                onClick={props.toggleNewAccount}
              >
                Cancel
              </button>
            </div>
          </div>
        </div>
      )}
    </React.Fragment>
  );
};

export default NewAccount;
