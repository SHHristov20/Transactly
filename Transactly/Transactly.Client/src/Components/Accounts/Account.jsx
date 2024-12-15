import React from "react";

const Account = (props) => {
  return (
    <React.Fragment>
      <div className="bg-white shadow-2xl w-full md:basis-[45%] lg:basis-[30%] p-5 rounded-lg mt-5 flex flex-col justify-between space-y-10">
        <div className="space-y-2">
          <h1 className="text-3xl font-bold">{props.currency}</h1>
          <h1 className="text-xl text-gray-500 font-bold">{props.symbol}</h1>
        </div>
        <h1 className="text-2xl font-semibold">${props.ammount}</h1>
      </div>
    </React.Fragment>
  );
};

export default Account;
