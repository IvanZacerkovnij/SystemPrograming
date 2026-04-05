#pragma once

#ifdef _WIN32
    #ifdef MYLIB_EXPORTS
        #define MYLIB_API __declspec(dllexport)
    #else
        #define MYLIB_API __declspec(dllimport)
    #endif
#else
    #define MYLIB_API
#endif

class PointManager;

#ifdef __cplusplus
extern "C" {
#endif

    MYLIB_API PointManager* CreatePointManager();
    MYLIB_API void DeletePointManager(PointManager* pm);

    MYLIB_API void AddPoint(PointManager* pm,int x, int y);
    MYLIB_API void RemovePoint(PointManager* pm, int index);
    MYLIB_API void GetPoint(PointManager* pm ,int index ,int* x, int* y);
    MYLIB_API int Count(PointManager* pm);

#ifdef __cplusplus
}
#endif