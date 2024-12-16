import React, { useEffect, useRef } from "react";
import { useUserContext } from "./Context/UserContext";

const Receive = (props) => {
  const { userObject } = useUserContext();
  const selectRef = useRef();

  useEffect(() => {
    console.log(userObject);
  }, [userObject]);

  return (
    <React.Fragment>
      <div className="fixed inset-0 bg-black bg-opacity-50 flex justify-center items-center">
        <div className="bg-white p-6 w-96 rounded-lg">
          <h1 className="text-2xl font-bold text-center">
            Receive funds from others
          </h1>
          <h1>
            Receive through email:{" "}
            <span className="font-semibold">{userObject.email}</span>
          </h1>
          <h1>
            Receive through phone number:{" "}
            <span className="font-semibold">{userObject.phoneNumber}</span>
          </h1>
          <h1>
            Receive through user tag:{" "}
            <span className="font-semibold">{userObject.userTag}</span>
          </h1>
          {userObject.accounts.map((account) => (
            <h1 key={account.id}>
              Receive through account number ({account.currency.currencyCode}):{" "}
              <span className="font-semibold">{account.accountNumber}</span>
            </h1>
          ))}

          <div className="flex gap-x-5 mt-5">
            <button
              className={"bg-gray-200 text-gray-800 rounded-full w-full py-3"}
              onClick={props.toggleReceive}
            >
              Close
            </button>
          </div>
        </div>
      </div>
    </React.Fragment>
  );
};

export default Receive;
