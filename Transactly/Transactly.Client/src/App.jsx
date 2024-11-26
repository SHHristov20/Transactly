import React from "react";
import Navbar from "./Components/Navbar/Navbar";

function App() {
  return (
    <React.Fragment>
      {/* <Navbar /> */}
      <div className="flex w-screen h-screen justify-center items-center">
        <div className="flex flex-col gap-y-6">
          <h1 className="text-center text-4xl font-bold pb-5">Register</h1>
          <input
            placeholder="First Name"
            className="border-b-[1px] focus:outline-none"
          />
          <input
            placeholder="Last Name"
            className="border-b-[1px] focus:outline-none"
          />
          <input
            placeholder="Phone"
            className="border-b-[1px] focus:outline-none"
          />
          <input
            placeholder="Password"
            className="border-b-[1px] focus:outline-none"
          />

          <button className="bg-pink-600 text-white rounded-full w-full py-3 my-2">
            Continue
          </button>
        </div>
      </div>
    </React.Fragment>
  );
}

export default App;
