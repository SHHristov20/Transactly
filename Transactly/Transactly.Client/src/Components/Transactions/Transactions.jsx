import React, { useEffect, useState } from "react";
import Transaction from "./Transaction";
import axios from "axios";
import { useUserContext } from "../Context/UserContext";

const Transactions = () => {
  const { token } = useUserContext();
  const [transactions, setTransactions] = useState([]);

  useEffect(() => {
    axios
      .get(`http://localhost:5165/Account/GetAllTransactions?token=${token}`)
      .then((res) => {
        console.log(res.data);
        setTransactions(res.data);
      })
      .catch((err) => {
        console.log(err);
      });
  }, []);

  return (
    <React.Fragment>
      <div className="p-6 overflow-y-scroll mb-10">
        <h1 className="font-semibold">
          <span className="text-blue-500">All </span>
          Transactions
        </h1>

        <div>
          <div>Today</div>
          {transactions.map((transaction) => (
            <Transaction key={transaction.id} transaction={transaction} />
          ))}
        </div>
      </div>
    </React.Fragment>
  );
};

export default Transactions;
