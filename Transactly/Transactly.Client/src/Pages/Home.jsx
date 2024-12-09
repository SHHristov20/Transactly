import React, { useState } from "react";

const Home = () => {
  const [isSidebarOpen, setIsSidebarOpen] = useState(false);

  const toggleSidebar = () => {
    setIsSidebarOpen(!isSidebarOpen);
  };

  return (
    <React.Fragment>
      <div className="h-screen flex overflow-hidden">
        <div
          className={`fixed lg:static top-0 left-0 h-full bg-gray-200 w-64 py-10 flex flex-col justify-between transform ${
            isSidebarOpen ? "translate-x-0" : "-translate-x-full"
          } transition-transform duration-300 lg:translate-x-0`}
        >
          <div className="space-y-2 px-8">
            <div className="h-16 w-16 bg-white rounded-full"></div>
            <h1>Denis Kovalev</h1>
          </div>
          <div className="">
            <h1 className="transition-colors duration-300 border-l-[4px] border-pink-400 px-8 py-3 hover:border-l-[4px] hover:border-pink-400 cursor-pointer">
              Accounts
            </h1>
            <h1 className="transition-colors duration-300 px-8 py-3 border-l-[4px] hover:border-pink-400 cursor-pointer">
              Cards
            </h1>
            <h1 className="transition-colors duration-300 px-8 py-3 border-l-[4px] hover:border-pink-400 cursor-pointer">
              Settings
            </h1>
            <h1 className="transition-colors duration-300 px-8 py-3 border-l-[4px] hover:border-pink-400 cursor-pointer">
              Log out
            </h1>
          </div>

          <div className="px-8">Transactly</div>
        </div>

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
            <span className="text-xl font-semibold">My App</span>
          </div>

          <div className="flex-1 p-6 overflow-y-auto">
            <h1 className="text-2xl font-bold mb-4">Main Content</h1>
            <p>
              This is the main content area. Resize the window to see the
              sidebar toggle on smaller screens.
            </p>
          </div>
        </div>

        {/* {isSidebarOpen && (
          <div
            className="fixed inset-0 bg-black bg-opacity-50 lg:hidden"
            onClick={toggleSidebar}
          ></div>
        )} */}
      </div>
    </React.Fragment>
  );
};

export default Home;
