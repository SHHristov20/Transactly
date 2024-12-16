import React, { useRef } from "react";
import { useUserContext } from "./Context/UserContext";
import axios from "axios";
import { useNavigate } from "react-router";

const Settings = (props) => {
  const navigate = useNavigate();
  const { userObject, token } = useUserContext();
  const emailRef = useRef();
  const phoneNumberRef = useRef();
  const userTagRef = useRef();
  const oldPasswordRef = useRef();

  const changeSettings = async () => {
    const user = {
      token: token,
      email: emailRef.current.value || userObject.email,
      phoneNumber: phoneNumberRef.current.value || userObject.phoneNumber,
      password: oldPasswordRef.current.value,
      userTag: userTagRef.current.value || userObject.userTag,
    };

    try {
      const response = await axios.post(
        "http://localhost:5165/User/Update",
        user
      );

      if (response.status === 200) {
        alert("Settings changed successfully");
        props.toggleSettings();
        navigate("/");
      }
    } catch (error) {
      alert(error.response.data);
    }
  };
  return (
    <React.Fragment>
      <div className="fixed inset-0 bg-black bg-opacity-50 flex justify-center items-center">
        <div className="bg-white p-6 w-96 rounded-lg">
          <h1 className="text-2xl font-bold text-center">Account Settings</h1>

          <input
            className="border-b-[1px] focus:outline-none py-2 w-full mb-4"
            placeholder="Email"
            placeholder={userObject.email}
            ref={emailRef}
          />
          <input
            className="border-b-[1px] focus:outline-none py-2 w-full mb-4"
            placeholder="Phone"
            placeholder={userObject.phoneNumber}
            ref={phoneNumberRef}
          />
          <input
            className="border-b-[1px] focus:outline-none py-2 w-full mb-4"
            placeholder="Address"
            placeholder={userObject.userTag}
            ref={userTagRef}
          />
          <input
            className="border-b-[1px] focus:outline-none py-2 w-full mb-4"
            placeholder="Old password"
            type="password"
            ref={oldPasswordRef}
          />

          <div className="flex gap-x-5 mt-5">
            <button
              className="bg-pink-600 text-white rounded-full w-full py-3"
              onClick={changeSettings}
            >
              Change
            </button>
            <button
              className={"bg-gray-200 text-gray-800 rounded-full w-full py-3"}
              onClick={props.toggleSettings}
            >
              Cancel
            </button>
          </div>
        </div>
      </div>
    </React.Fragment>
  );
};

export default Settings;
