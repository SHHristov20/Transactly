import React from "react";
import { Link } from "react-router";
const Register = () => {
  return (
    <React.Fragment>
      <div className="flex w-screen h-screen justify-center items-center">
        <div className="flex flex-col gap-y-6 md:w-1/2 xl:w-1/3">
          <h1 className="text-center text-4xl font-bold pb-5">Register</h1>
          <input
            placeholder="First Name"
            className="border-b-[1px] focus:outline-none py-2"
          />
          <input
            placeholder="Last Name"
            className="border-b-[1px] focus:outline-none py-2"
          />
          <input
            placeholder="Phone"
            className="border-b-[1px] focus:outline-none py-2"
          />
          <input
            placeholder="Password"
            className="border-b-[1px] focus:outline-none py-2"
          />

          <Link to="/">
            <button className="bg-pink-600 text-white rounded-full w-full py-3 my-2">
              Continue
            </button>
          </Link>
        </div>
      </div>
    </React.Fragment>
  );
};

export default Register;
