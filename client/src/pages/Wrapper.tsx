import { AuthContextProvider } from "../contexts/AuthContextProvider";
import { AppLayoutUI } from "./AppLayoutUI";

export const Wrapper = (props: any) => {
  return (
    <AuthContextProvider>
      <AppLayoutUI>{props.children}</AppLayoutUI>
    </AuthContextProvider>
  );
};
