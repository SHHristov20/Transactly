import React from "react";
import Transaction from "./Transaction";

const Transactions = () => {
  return (
    <React.Fragment>
      <div className="p-6 overflow-y-scroll mb-10">
        <h1 className="font-semibold">
          <span className="text-blue-500">All </span>
          Transactions
        </h1>

        <div>
          <div>Today</div>
          <Transaction />
          <Transaction />
          <Transaction />
          <Transaction />
          <Transaction />
          <Transaction />
          <Transaction />
          <Transaction />
          <Transaction />
          <Transaction />
          <Transaction />
        </div>
      </div>
    </React.Fragment>
  );
};

export default Transactions;
