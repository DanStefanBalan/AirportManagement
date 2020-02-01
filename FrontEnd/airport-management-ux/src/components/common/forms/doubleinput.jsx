import React from "react";

const DoubleInput = ({
  name1,
  name2,
  label,
  value1,
  value2,
  onChange,
  background1,
  background2,
  error1,
  error2,
  type,
  placeholder,
  rowType = "even"
}) => {
  return (
    <div className={"double-input-wrapper " + rowType}>
      <div className="double-input">
        <label htmlFor="name1">{label}</label>
        <input
          value={value1}
          id={name1}
          type={type ? type : "text"}
          className={error1 ? "element-input has-error" : "element-input"}
          onChange={onChange}
          name={name1}
          placeholder={placeholder}
          style={{
            backgroundImage: "url(" + background1 + ")",
            backgroundPosition: "left center",
            backgroundRepeat: "no-repeat"
          }}
        />
        <input
          value={value2}
          id={name2}
          type={type ? type : "text"}
          className={error2 ? "element-input has-error" : "element-input"}
          onChange={onChange}
          name={name2}
          placeholder={placeholder}
          style={{
            backgroundImage: "url(" + background2 + ")",
            backgroundPosition: "left center",
            backgroundRepeat: "no-repeat"
          }}
        />
      </div>
      <div className="error-wrapper">
        {error1 && <div className="error-message">{error1}</div>}
        {error2 && <div className="error-message">{error2}</div>}
      </div>
    </div>
  );
};

export default DoubleInput;
