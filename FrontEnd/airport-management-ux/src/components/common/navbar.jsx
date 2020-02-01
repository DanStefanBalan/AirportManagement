import React, { Component } from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faSignInAlt,
  faSignOutAlt,
  faUserPlus
} from "@fortawesome/free-solid-svg-icons";

import "../../styles/common/navbar.scss";
import { Link } from "react-router-dom";

class NavBar extends Component {
  state = {
    logged: true,
    user: ""
  };

  isLoggedIn() {
    if (this.state.logged === true)
      return (
        <Link to="/login">
          <FontAwesomeIcon icon={faSignInAlt} />
          Login
        </Link>
      );
    else
      return (
        <Link to="/">
          <FontAwesomeIcon icon={faSignOutAlt} />
          Logout
        </Link>
      );
  }

  render() {
    return (
      <nav className="navigation-bar">
        <div className="navContainer">
          <div className="imageContainer">
            <Link to="/">
              <img
                className="logo"
                src={require("../../resources/images/logo.png")}
                alt="logo-airport"
              />
            </Link>
          </div>
          <div className="option">{this.isLoggedIn()}</div>
          <div className="option">
            <Link to="/register">
              <FontAwesomeIcon icon={faUserPlus} />
              Sign up
            </Link>
          </div>
        </div>
      </nav>
    );
  }
}

export default NavBar;
