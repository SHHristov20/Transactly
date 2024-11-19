import React from "react";
import { RxHamburgerMenu } from "react-icons/rx";
import { FaSearch } from "react-icons/fa";
import { CiSettings } from "react-icons/ci";
import { IoIosNotifications } from "react-icons/io";

function App() {
  return (
    <React.Fragment>
      <div className="w-screen flex justify-between p-5">
        <div className="flex justify-between items-center w-screen">
          <RxHamburgerMenu className="md:hidden text-2xl" />
          <h1 className="text-3xl md:text-4xl">Home</h1>
          <div className="md:hidden w-10 h-10 cursor-pointer bg-purple-500 rounded-full"></div>
        </div>
        <div className="space-x-5 hidden md:flex">
          <div className="flex items-center bg-[#F5F7FA] py-2 px-5 rounded-full">
            <FaSearch className="text-[#8BA3CB]" />
            <input
              type="text"
              placeholder="Search for something"
              className="px-2 focus:outline-none bg-[#F5F7FA] placeholder:text-[#8BA3CB]"
            />
          </div>
          <div className="bg-[#F5F7FA] cursor-pointer rounded-full flex items-center justify-center w-12 h-12">
            <CiSettings className="text-2xl" />
          </div>
          <div className="bg-[#F5F7FA] cursor-pointer rounded-full flex items-center justify-center w-12 h-12">
            <IoIosNotifications className="text-2xl text-[#FE5C73]" />
          </div>

          <div className="w-12 h-12 cursor-pointer bg-purple-500 rounded-full"></div>
        </div>
      </div>
    </React.Fragment>
  );
}

export default App;
