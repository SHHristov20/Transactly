import React from "react";

const Transaction = () => {
  return (
    <React.Fragment>
      <div className="flex justify-between items-center p-5 space-x-3 rounded-xl hover:shadow-2xl transition-shadow duration-300 cursor-pointer">
        <div className="flex space-x-3">
          <div className="h-12 w-12 bg-white shadow-2xl rounded-full"></div>
          <div>
            <h1 className="font-semibold">Exchange from USD</h1>
            <h1 className="text-gray-500">16:42</h1>
          </div>
        </div>
        <div>
          <h1 className="font-semibold">+ $923</h1>
          <h1 className="text-gray-500">- $123</h1>
        </div>
      </div>
    </React.Fragment>
  );
};

export default Transaction;
