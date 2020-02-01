import React, { Component } from "react";
import Input from "../common/forms/input";
import "../../styles/forms/login.scss";
import data from "../../resources/content.json";
import { loginSchema, registerSchema } from "../../schemas/loginSchema";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faSignInAlt, faUserPlus } from "@fortawesome/free-solid-svg-icons";

class LoginForm extends Component {
  constructor(props) {
    super(props);
    this.switchToLogin = this.switchToLogin.bind(this);
    this.switchToLogUp = this.switchToLogUp.bind(this);
    this.switchForm = this.switchForm.bind(this);
    this.state = {
      account: {
        username: "",
        password: "",
        passwordConfirmation: "",
        email: ""
      },
      errors: {},
      formType: "Sign Up",
      signUpActive: "active",
      newAccountActive: ""
    };
  }

  switchToLogin() {
    this.setState({
      formType: "New Account",
      signUpActive: "",
      newAccountActive: "active",
      account: {
        username: "",
        password: "",
        passwordConfirmation: "",
        email: ""
      },
      errors: {}
    });
  }

  switchToLogUp() {
    this.setState({
      formType: "Sign Up",
      signUpActive: "active",
      newAccountActive: "",
      account: {
        username: "",
        password: ""
      },
      errors: {}
    });
  }

  switchForm = () => {
    if (this.state.formType === "New Account")
      return (
        <div>
          <Input
            name={data.login.passwordConfirmation.name}
            value={this.state.account.passwordConfirmation}
            error={this.state.errors.passwordConfirmation}
            placeholder="&#xf023; Password confirmation"
            onChange={this.handleChange}
            type="password"
          />
          <Input
            name={data.login.email.name}
            value={this.state.account.email}
            error={this.state.errors.email}
            placeholder="&#xf199; Email"
            onChange={this.handleChange}
          />
        </div>
      );
  };

  validate = () => {
    const account = { ...this.state.account };
    const errorMessage = {};
    const options = { abortEarly: false };
    var schema = registerSchema;
    if (this.state.formType === "Sign Up") {
      schema = loginSchema;
      const { error } = schema.validate(
        {
          username: account.username,
          password: account.password
        },
        options
      );
    }
    const { error } = schema.validate(
      {
        username: account.username,
        password: account.password,
        passwordConfirmation: account.passwordConfirmation,
        email: account.email
      },
      options
    );

    if (!error) return null;
    for (let item of error.details) {
      errorMessage[item.path[0]] = item.message;
    }
    this.setState({ errors: errorMessage });
  };

  handleChange = ({ currentTarget: input }) => {
    const account = { ...this.state.account };
    account[input.name] = input.value;
    this.setState({ account });
  };

  handleSubmit = e => {
    e.preventDefault();
    this.validate();
  };

  render() {
    const { account, errors } = this.state;
    return (
      <div className="formWrapper">
        <button
          className={
            "title-wrapper " + (this.state.signUpActive ? "active" : "")
          }
          onClick={this.switchToLogUp}
        >
          <div className="icon">
            <FontAwesomeIcon icon={faSignInAlt} />
          </div>
          {data.login.signInTitle}
        </button>
        <button
          className={
            "title-wrapper " + (this.state.newAccountActive ? "active" : "")
          }
          onClick={this.switchToLogin}
        >
          <div className="icon">
            <FontAwesomeIcon icon={faUserPlus} />
          </div>
          {data.login.singUpTitle}
        </button>
        <form onSubmit={this.handleSubmit}>
          <Input
            name={data.login.username.name}
            value={account.username}
            error={errors.username}
            placeholder="&#xf007; Username"
            //de modificat stringul hardcodat
            onChange={this.handleChange}
          />
          <Input
            name={data.login.password.name}
            value={account.password}
            error={errors.password}
            type="password"
            placeholder="&#xf023; Password"
            //de modificat stringul hardcodat
            onChange={this.handleChange}
          />
          {this.switchForm()}
          <button className="loginButton">
            {this.state.signUpActive
              ? data.login.signInButton
              : data.login.singUpButton}
          </button>
        </form>
      </div>
    );
  }
}

export default LoginForm;
