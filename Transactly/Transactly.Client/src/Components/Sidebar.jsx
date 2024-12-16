/* eslint-disable react/prop-types */
import React from "react";
import { useUserContext } from "./Context/UserContext";
import { useNavigate } from "react-router";

const Sidebar = (props) => {
  const navigate = useNavigate();
  const { userObject, logout } = useUserContext();

  const handleLogout = async () => {
    await logout();
    navigate("/login");
  };

  return (
    <React.Fragment>
      <div
        className={`fixed lg:static top-0 left-0 h-full bg-gray-200 w-64 py-10 flex flex-col justify-between transform ${
          props.isSidebarOpen ? "translate-x-0" : "-translate-x-full"
        } transition-transform duration-300 lg:translate-x-0`}
      >
        <div className="space-y-2 px-8">
          <div className="h-16 w-16 bg-white rounded-full"></div>
          <h1>
            {userObject.firstName} {userObject.lastName}
          </h1>
        </div>
        <div className="">
          <h1 className="transition-colors duration-300 border-l-[4px] border-pink-400 px-8 py-3 hover:border-l-[4px] hover:border-pink-400 cursor-pointer">
            Accounts
          </h1>
          <h1 className="transition-colors duration-300 px-8 py-3 border-l-[4px] hover:border-pink-400 cursor-pointer">
            Cards
          </h1>
          <h1
            className="transition-colors duration-300 px-8 py-3 border-l-[4px] hover:border-pink-400 cursor-pointer"
            onClick={props.toggleSettings}
          >
            Settings
          </h1>
          <h1
            className="transition-colors duration-300 px-8 py-3 border-l-[4px] hover:border-pink-400 cursor-pointer"
            onClick={handleLogout}
          >
            Log out
          </h1>
        </div>

        <div className="px-8">Transactly</div>
      </div>
    </React.Fragment>
  );
};

export default Sidebar;
