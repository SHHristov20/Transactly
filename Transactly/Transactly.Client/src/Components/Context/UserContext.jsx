import axios from "axios";
import React, { createContext, useContext, useState, useEffect } from "react";

const UserContext = createContext();

export const UserProvider = ({ children }) => {
  const [userObject, setUserObject] = useState(null);
  const [token, setToken] = useState(() => localStorage.getItem("authToken"));

  const fetchUserDetails = async (authToken) => {
    try {
      const response = await axios.get(
        `http://localhost:5165/User/GetCurrentUser?sessionToken=${authToken}`
      );
      if (response.status === 200) {
        setUserObject(response.data);
      }
    } catch (error) {
      console.error("Error fetching user details:", error);
      logout();
    }
  };

  useEffect(() => {
    if (token) {
      fetchUserDetails(token);
    }
  }, [token]);

  const login = async (authToken) => {
    localStorage.setItem("authToken", authToken);
    setToken(authToken);
    await fetchUserDetails(authToken);
  };

  const logout = () => {
    localStorage.removeItem("authToken");
    setUserObject(null);
    setToken(null);
  };

  return (
    <UserContext.Provider value={{ userObject, token, login, logout }}>
      {children}
    </UserContext.Provider>
  );
};

export const useUserContext = () => {
  return useContext(UserContext);
};
