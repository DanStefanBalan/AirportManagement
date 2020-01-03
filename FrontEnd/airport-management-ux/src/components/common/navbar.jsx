import React, { Component } from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faSignInAlt, faSignOutAlt } from "@fortawesome/free-solid-svg-icons";
import "../../styles/navbar.scss";

class NavBar extends Component {
  state = {
    logged: true
  };

  isLoggedIn() {
    if (this.state.logged === true)
      return (
        <label>
          <FontAwesomeIcon icon={faSignInAlt} />
          Login
        </label>
      );
    else
      return (
        <label>
          <FontAwesomeIcon icon={faSignOutAlt} />
          Logout
        </label>
      );
  }

  render() {
    return (
      <nav className="navigation-bar">
        <div className="navContainer">
          <img
            className="logo"
            src={require("../../resources/logo.png")}
            alt="logo-airport"
          />
          <div className="loginOption">{this.isLoggedIn()}</div>
        </div>
      </nav>
    );
  }
}

export default NavBar;
