import React from "react";

const Deposit = (props) => {
  return (
    <React.Fragment>
      <div className="fixed inset-0 bg-black bg-opacity-50 flex justify-center items-center">
        <div className="bg-white p-6 w-96 rounded-lg">
          <h1 className="text-2xl font-bold text-center">Deposit Money</h1>

          <input
            placeholder="Amount"
            className="border-b-[1px] focus:outline-none py-2 w-full mb-4"
          />

          <input
            placeholder="Cardholder Name"
            className="border-b-[1px] focus:outline-none py-2 w-full mb-4"
          />

          <input
            placeholder="Card Number"
            className="border-b-[1px] focus:outline-none py-2 w-full mb-4"
            maxLength={16}
          />

          <div className="flex gap-4">
            <input
              placeholder="MM/YY"
              className="border-b-[1px] focus:outline-none py-2 w-1/2"
              maxLength={5}
            />
            <input
              placeholder="CVV"
              className="border-b-[1px] focus:outline-none py-2 w-1/2"
              maxLength={3}
            />
          </div>

          <div className="flex gap-x-5 mt-5">
            <button className="bg-pink-600 text-white rounded-full w-full py-3">
              Deposit
            </button>
            <button
              className={"bg-gray-200 text-gray-800 rounded-full w-full py-3"}
              onClick={props.toggleDeposit}
            >
              Cancel
            </button>
          </div>
        </div>
      </div>
    </React.Fragment>
  );
};

export default Deposit;
