import React, { useState } from "react";
import Header from "../Components/Header";
import Sidebar from "../Components/Sidebar";
import Accounts from "../Components/Accounts";

const Home = () => {
  const [isSidebarOpen, setIsSidebarOpen] = useState(false);

  const toggleSidebar = () => {
    setIsSidebarOpen(!isSidebarOpen);
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
          <Header />
          <Accounts />
        </div>
      </div>
    </React.Fragment>
  );
};

export default Home;
