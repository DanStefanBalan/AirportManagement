import React, { Component } from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faPlane,
  faMapMarkedAlt,
  faPlaneDeparture
} from "@fortawesome/free-solid-svg-icons";
import "../../styles/common/navbarAdmin.scss";
import { Link } from "react-router-dom";

class NavBarAdmin extends Component {
  state = {
    logged: true,
    user: ""
  };

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
          <div className="option">
            <Link to="/admin/airports">
              <FontAwesomeIcon icon={faPlane} />
              Airport
            </Link>
          </div>
          <div className="option">
            <Link to="/admin/aircraft">
              <FontAwesomeIcon icon={faPlane} />
              Aircraft
            </Link>
          </div>
          <div className="option">
            <Link to="/admin/destination">
              <FontAwesomeIcon icon={faMapMarkedAlt} />
              Destination
            </Link>
          </div>
          <div className="option">
            <Link to="/admin/gate">
              <FontAwesomeIcon icon={faPlaneDeparture} />
              Gate
            </Link>
          </div>
          <div className="option">
            <Link to="/admin/terminal">
              <FontAwesomeIcon icon={faMapMarkedAlt} />
              Terminal
            </Link>
          </div>
          <div className="option">
            <Link to="/admin/flight">
              <FontAwesomeIcon icon={faMapMarkedAlt} />
              Flight
            </Link>
          </div>
        </div>
      </nav>
    );
  }
}

export default NavBarAdmin;
