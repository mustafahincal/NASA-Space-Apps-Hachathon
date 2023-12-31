"use client";
import Image from "next/image";
import React, { useEffect, useState } from "react";
import { RxCross1 } from "react-icons/rx";
import { AnimatePresence, motion } from "framer-motion";
import Link from "next/link";
import { CgMenuMotion } from "react-icons/cg";
import { usePathname, useRouter } from "next/navigation";
import { useAuthContext } from "../_contexts/AuthContext";

const Menu = () => {
  const [isOpen, setIsOpen] = useState(false);
  const { state, dispatch } = useAuthContext();
  const path = usePathname();
  const router = useRouter();
  const toggle = () => setIsOpen(!isOpen);
  const variants = {
    hidden: { opacity: 0, x: 0, y: -200 },
    enter: { opacity: 1, x: 0, y: 0 },
    exit: { opacity: 0, x: 0, y: -200 },
  };

  useEffect(() => setIsOpen(false), [path]);

  return (
    <div className="pt-5">
      <button onClick={toggle}>
        <CgMenuMotion
          className={` ${path === "/" ? "text-[#375bec]" : "text-blood"}`}
          size={50}
        />
      </button>
      <AnimatePresence mode="wait">
        {isOpen && (
          <motion.div
            variants={variants}
            transition={{ ease: "easeIn" }}
            initial="hidden"
            whileInView="enter"
            exit="exit"
            className="fixed flex filter backdrop-filter backdrop-blur-2xl bg-opacity-95 flex-col text-white bg-black top-0 left-0 h-screen w-full "
          >
            <div className="flex w-full py-2 items-center  px-24 top-0 flex-row justify-between">
              <div className="flex flex-row gap-5 items-center text-center ">
                <div className="flex gap-2 items-center">
                  <Link href={"/"} className="w-[100px] h-auto">
                    <img src="/assets/spaceapps-logo.jpg" alt="" />
                  </Link>
                  <Link href={"/"} className="w-[100px] h-auto">
                    <img src="/assets/nasa-logo.png" alt="" />
                  </Link>
                </div>
                {state?.isLoggedIn ? (
                  <h1 className="text-2xl font-bold tracking-wider bg-white rounded text-black px-3 py-1">
                    {state?.user?.fullName}
                  </h1>
                ) : null}
              </div>

              <button onClick={toggle}>
                <RxCross1 className="text-blood font-extrabold" size={45} />
              </button>
            </div>
            <div className="flex flex-row h-[75vh] w-full justify-around items-center">
              <div>
                <ul className="flex gap-6 text-6xl flex-col items-center">
                  {state?.isLoggedIn ? (
                    <>
                      <li>
                        <Link
                          className={`custom-link ${
                            path === "/profile" ? "bg-white text-black" : ""
                          }`}
                          href={"/profile"}
                        >
                          Profile
                        </Link>
                      </li>
                      <li>
                        <button
                          type="button"
                          className={`custom-link ${
                            path === "---" ? "bg-white" : ""
                          }`}
                          onClick={() => {
                            dispatch({ type: "LOGOUT" });
                            router.push("/");
                          }}
                        >
                          Logout
                        </button>
                      </li>
                    </>
                  ) : (
                    <>
                      <li>
                        <Link
                          className={`custom-link ${
                            path === "---" ? "bg-white" : ""
                          }`}
                          href={"/login"}
                        >
                          Login
                        </Link>
                      </li>
                      <li>
                        <Link
                          href={"/signup"}
                          className={`custom-link ${
                            path === "---" ? "bg-white" : ""
                          }`}
                        >
                          Register
                        </Link>
                      </li>
                    </>
                  )}
                  <li>
                    <Link
                      className={`custom-link ${
                        path === "/" ? "bg-white text-black" : ""
                      }`}
                      href={"/"}
                    >
                      Home
                    </Link>
                  </li>

                  <li>
                    <Link
                      className={`custom-link ${
                        path === "/explore" ? "bg-white text-black" : ""
                      }`}
                      href={"/explore"}
                    >
                      Explore
                    </Link>
                  </li>
                  <li>
                    <Link
                      href={"/projects/add"}
                      className={`custom-link ${
                        path === "/projects/add" ? "bg-white text-black" : ""
                      }`}
                    >
                      Share Project
                    </Link>
                  </li>
                </ul>
              </div>
              <div className="flex gap-4 items-center flex-col">
                <Image
                  src={"/assets/team-logo.png"}
                  width={400}
                  height={400}
                  alt=""
                />
              </div>
            </div>
          </motion.div>
        )}
      </AnimatePresence>
    </div>
  );
};

export default Menu;
