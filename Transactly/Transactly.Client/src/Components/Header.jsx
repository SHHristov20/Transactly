import React from "react";
import { FaPlus } from "react-icons/fa6";
import { FaArrowsRotate } from "react-icons/fa6";
import { FaArrowLeft } from "react-icons/fa6";
import { FaArrowRight } from "react-icons/fa6";

const Header = () => {
  return (
    <React.Fragment>
      <div className="flex-1 p-6 overflow-y-auto space-y-3">
        <div className="flex flex-col md:flex-row justify-between">
          <h1 className="text-4xl font-bold mb-4">
            $230,630<span className="text-gray-500">.50</span>
          </h1>

          <div className="flex gap-x-5">
            <div className="bg-white w-14 h-14 rounded-full flex justify-center items-center text-2xl cursor-pointer hover:bg-gray-200 transition-colors duration-300">
              <FaPlus />
            </div>
            <div className="bg-white w-14 h-14 rounded-full flex justify-center items-center text-2xl cursor-pointer hover:bg-gray-200 transition-colors duration-300">
              <FaArrowsRotate />
            </div>
            <div className="bg-white w-14 h-14 rounded-full flex justify-center items-center text-2xl cursor-pointer hover:bg-gray-200 transition-colors duration-300">
              <FaArrowLeft />
            </div>
            <div className="bg-pink-400 w-14 h-14 rounded-full flex justify-center items-center text-2xl cursor-pointer hover:bg-pink-500 transition-colors duration-300">
              <FaArrowRight />
            </div>
          </div>
        </div>
        <p>Total balance in base currency of USD.</p>

        <div className="flex justify-between md:justify-start md:gap-x-10 border-b-[2px] py-2">
          <h1 className="px-2 border-l-[2px] transition-colors duration-300 hover:border-pink-400 cursor-pointer">
            Accounts
          </h1>
          <h1 className="px-2 border-l-[2px] transition-colors duration-300 hover:border-pink-400 cursor-pointer">
            Summary
          </h1>
          <h1 className="px-2 border-l-[2px] transition-colors duration-300 hover:border-pink-400 cursor-pointer">
            Transactions
          </h1>
        </div>
      </div>
    </React.Fragment>
  );
};

export default Header;
