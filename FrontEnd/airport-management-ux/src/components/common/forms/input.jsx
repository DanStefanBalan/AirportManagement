import React from "react";

const Input = ({
  name,
  label,
  value,
  onChange,
  background,
  error,
  type,
  placeholder,
  rowType = "even"
}) => {
  return (
    <div
      className={(error ? "smaller-input-wrapper " : "input-wrapper ") + rowType}
    >
      <div className="input">
        <label htmlFor="name">{label}</label>
        <input
          value={value}
          id={name}
          type={type ? type : "text"}
          className={error ? "element-input has-error" : "element-input"}
          onChange={onChange}
          name={name}
          placeholder={placeholder}
          style={{
            backgroundImage: "url(" + background + ")",
            backgroundPosition: "left center",
            backgroundRepeat: "no-repeat"
          }}
        />
      </div>
      <div className="error-wrapper">
        {error && <div className="error-message">{error}</div>}
      </div>
    </div>
  );
};

export default Input;
