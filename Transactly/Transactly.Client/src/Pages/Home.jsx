import React, { useState } from "react";
import Header from "../Components/Header";
import Sidebar from "../Components/Sidebar";
import Accounts from "../Components/Accounts/Accounts";
import Transactions from "../Components/Transactions/Transactions";
import Deposit from "../Components/Deposit";
import Transfer from "../Components/Transfer";
import Receive from "../Components/Receive";

const Home = () => {
  const [tab, setTab] = useState("Accounts");
  const [isSidebarOpen, setIsSidebarOpen] = useState(false);
  const [isDepositOpen, setIsDepositOpen] = useState(false);
  const [isTransferOpen, setIsTransferOpen] = useState(false);
  const [isReceiveOpen, setIsReceiveOpen] = useState(false);

  const toggleSidebar = () => {
    setIsSidebarOpen(!isSidebarOpen);
  };

  const toggleDeposit = () => {
    setIsDepositOpen(!isDepositOpen);
  };

  const toggleTransfer = () => {
    setIsTransferOpen(!isTransferOpen);
  };

  const toggleReceive = () => {
    setIsReceiveOpen(!isReceiveOpen);
  };

  return (
    <React.Fragment>
      <div className="h-screen flex overflow-hidden">
        {isSidebarOpen && (
          <div
            className="fixed inset-0 bg-black bg-opacity-50 lg:hidden"
            onClick={toggleSidebar}
          ></div>
        )}

        <Sidebar isSidebarOpen={isSidebarOpen} />

        <div className="flex-1 flex flex-col bg-gray-100">
          <div className="bg-white shadow-md p-4 flex items-center justify-between lg:hidden">
            <button
              className="text-gray-800 focus:outline-none"
              onClick={toggleSidebar}
            >
              <svg
                className="w-6 h-6"
                fill="none"
                stroke="currentColor"
                viewBox="0 0 24 24"
                xmlns="http://www.w3.org/2000/svg"
              >
                <path
                  strokeLinecap="round"
                  strokeLinejoin="round"
                  strokeWidth={2}
                  d="M4 6h16M4 12h16m-7 6h7"
                />
              </svg>
            </button>
            <span className="text-xl font-semibold">Dashboard</span>
          </div>
          <Header
            tab={tab}
            setTab={setTab}
            toggleDeposit={toggleDeposit}
            toggleTransfer={toggleTransfer}
            toggleReceive={toggleReceive}
          />

          {tab === "Accounts" && <Accounts />}
          {tab === "Transactions" && <Transactions />}
        </div>
      </div>

      {isDepositOpen && <Deposit toggleDeposit={toggleDeposit} />}
      {isTransferOpen && <Transfer toggleTransfer={toggleTransfer} />}
      {isReceiveOpen && <Receive toggleReceive={toggleReceive} />}
    </React.Fragment>
  );
};

export default Home;
