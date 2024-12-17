import React from "react";
import { useUserContext } from "../Context/UserContext";

const Transaction = (props) => {
  const { userObject } = useUserContext();

  return (
    <React.Fragment>
      <div className="flex justify-between items-center p-5 space-x-3 rounded-xl hover:shadow-2xl transition-shadow duration-300 cursor-pointer">
        <div className="flex space-x-3">
          <div className="h-12 w-12 bg-white shadow-2xl rounded-full"></div>
          <div>
            <h1 className="font-semibold">{props.transaction.type.type}</h1>
            <h1 className="text-gray-500">
              {new Date(props.transaction.date).toLocaleDateString()}{" "}
              {new Date(props.transaction.date).toLocaleTimeString()}
            </h1>
          </div>
        </div>
        <div>
          {props.transaction.toAccount.userId == userObject.id ? (
            <h1 className="text-green-500">
              +{props.transaction.amount}{" "}
              {props.transaction.toAccount.currency.currencyName}
            </h1>
          ) : (
            <h1 className="text-red-500">
              -{props.transaction.amount}{" "}
              {props.transaction.fromAccount.currency.currencyName}
            </h1>
          )}
        </div>
      </div>
    </React.Fragment>
  );
};

export default Transaction;
