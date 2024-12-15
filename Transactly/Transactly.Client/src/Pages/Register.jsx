import React, { useRef } from "react";
import { useNavigate } from "react-router";
import axios from "axios";

const Register = () => {
  const navigate = useNavigate();
  const firstNameRef = useRef();
  const lastNameRef = useRef();
  const phoneRef = useRef();
  const emailRef = useRef();
  const passwordRef = useRef();

  const register = async () => {
    const response = await axios.post("http://localhost:5165/User/Create", {
      firstName: firstNameRef.current.value,
      lastName: lastNameRef.current.value,
      phoneNumber: phoneRef.current.value,
      email: emailRef.current.value,
      password: passwordRef.current.value,
    });

    if (response.status === 200) {
      navigate("/");
    }
  };

  return (
    <React.Fragment>
      <div className="flex w-screen h-screen justify-center items-center">
        <div className="flex flex-col gap-y-6 md:w-1/2 xl:w-1/3">
          <h1 className="text-center text-4xl font-bold pb-5">Register</h1>
          <input
            placeholder="First Name"
            className="border-b-[1px] focus:outline-none py-2"
            ref={firstNameRef}
          />
          <input
            placeholder="Last Name"
            className="border-b-[1px] focus:outline-none py-2"
            ref={lastNameRef}
          />
          <input
            placeholder="Phone"
            className="border-b-[1px] focus:outline-none py-2"
            ref={phoneRef}
          />
          <input
            placeholder="Email"
            className="border-b-[1px] focus:outline-none py-2"
            ref={emailRef}
          />
          <input
            placeholder="Password"
            className="border-b-[1px] focus:outline-none py-2"
            ref={passwordRef}
          />

          {/* <Link to="/"> */}
          <button
            className="bg-pink-600 text-white rounded-full w-full py-3 my-2"
            onClick={register}
          >
            Register
          </button>
          {/* </Link> */}
        </div>
      </div>
    </React.Fragment>
  );
};

export default Register;
