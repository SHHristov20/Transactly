import React, { useRef, useContext } from "react";
import { useUserContext } from "../Components/Context/UserContext";
import { useNavigate } from "react-router";
import axios from "axios";

const Login = () => {
  const { login } = useUserContext();

  const navigate = useNavigate();
  const emailRef = useRef();
  const passwordRef = useRef();

  const handleLogin = async () => {
    const response = await axios.post("http://localhost:5165/User/Login", {
      email: emailRef.current.value,
      password: passwordRef.current.value,
    });

    console.log(response);

    if (response.status === 200) {
      await login(response.data);
      navigate("/");
    }
  };

  return (
    <React.Fragment>
      <div className="flex w-screen h-screen justify-center items-center">
        <div className="flex flex-col gap-y-6 md:w-1/2 xl:w-1/3">
          <h1 className="text-center text-4xl font-bold pb-5">Login</h1>
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

          <button
            className="bg-pink-600 text-white rounded-full w-full py-3 my-2"
            onClick={handleLogin}
          >
            Login
          </button>
        </div>
      </div>
    </React.Fragment>
  );
};

export default Login;
