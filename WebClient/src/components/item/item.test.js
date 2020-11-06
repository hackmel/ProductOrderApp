import React from "react";
import { shallow } from "enzyme";
import { Item } from ".";

const item = {
  name: "Cookies",
  price: "$5.00",
};

describe("Item", () => {
  it("renders", () => {
    shallow(<Item item={item} />);
  });
});
