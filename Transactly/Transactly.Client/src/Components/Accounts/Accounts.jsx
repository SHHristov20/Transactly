import React, { useState } from "react";
import Account from "./Account";
import NewAccount from "./NewAccount";

const Accounts = () => {
  const [toggleNewAccount, setToggleNewAccount] = useState(false);

  const handleToggleNewAccount = () => {
    setToggleNewAccount(!toggleNewAccount);
  };

  return (
    <React.Fragment>
      <div className="p-6">
        <div className="flex justify-between">
          <h1 className="font-semibold">
            <span className="text-blue-500">All</span> Accounts
          </h1>
          <h1
            className="text-blue-500 font-semibold cursor-pointer hover:text-blue-600 transition-colors duration-300"
            onClick={handleToggleNewAccount}
          >
            Add new account
          </h1>
        </div>

        <div className="md:flex md:flex-wrap gap-x-5 justify-between">
          <Account
            currency={"British pounds"}
            symbol={"GBP"}
            ammount={"999.99"}
          />
          <Account
            currency={"British pounds"}
            symbol={"GBP"}
            ammount={"999.99"}
          />
          <Account
            currency={"British pounds"}
            symbol={"GBP"}
            ammount={"999.99"}
          />
        </div>
      </div>

      {toggleNewAccount && (
        <NewAccount toggleNewAccount={handleToggleNewAccount} />
      )}
    </React.Fragment>
  );
};

export default Accounts;
